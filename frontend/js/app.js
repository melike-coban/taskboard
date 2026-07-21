console.log("TaskBoard JavaScript yüklendi.");

const form = document.querySelector("#task-form");
const titleInput = document.querySelector("#task-title");
const prioritySelect = document.querySelector("#priority");
const tableBody = document.querySelector("#task-table-body");
const totalCount = document.querySelector("#total-count");
const openCount = document.querySelector("#open-count");
const doneCount = document.querySelector("#done-count");
const progressCount = document.querySelector("#progress-count");
const emptyState = document.querySelector(".empty-state");
const statusFilter = document.querySelector("#status-filter");
const priorityFilter = document.querySelector("#priority-filter");
const loadSampleBtn = document.querySelector("#load-sample-btn");
const clearStorageBtn = document.querySelector("#clear-storage-btn");
const message = document.querySelector("#message");

let tasks = [];

form.addEventListener("submit", function (event) {
  event.preventDefault();

  const title = titleInput.value.trim();
  const priority = prioritySelect.value;

  if (!title) return;

  const newTask = createTask(title, priority);

  tasks.push(newTask);

  saveTasks();

  applyFilters();

  form.reset();
  titleInput.focus();
});

function createTask(title, priority) {
  return {
    id: Date.now(),
    title,
    priority,
    status: "open",
    createdAt: new Date().toLocaleDateString("tr-TR"),
  };
}

function renderTasks(items) {
  tableBody.innerHTML = items
    .map((task) => {
      let priorityText = "";
      let priorityClass = "";

      if (task.priority === "high") {
        priorityText = "Yüksek";
        priorityClass = "high";
      } else if (task.priority === "normal") {
        priorityText = "Normal";
        priorityClass = "normal";
      } else {
        priorityText = "Düşük";
        priorityClass = "low";
      }

      let statusClass = "";
      let statusText = "";

      if (task.status === "open") {
        statusClass = "status-open";
        statusText = "Açık";
      } else {
        statusClass = "status-done";
        statusText = "Tamamlandı";
      }

      return `
      <tr>
        <td>${task.title}</td>

        <td>
          <span class="badge ${priorityClass}">
            ${priorityText}
          </span>
        </td>

        <td>
          <span class="status ${statusClass}">
            ${statusText}
          </span>
        </td>

        <td>${task.createdAt}</td>

        <td>
          <button class="btn complete-btn" data-id="${task.id}">
            Tamamla
          </button>
        </td>
      </tr>
      `;
    })
    .join("");

  updateCounts();
  updateEmptyState();
}

function updateCounts() {
  totalCount.textContent = tasks.length;

  openCount.textContent = tasks.filter((task) => task.status === "open").length;

  doneCount.textContent = tasks.filter((task) => task.status === "done").length;

  progressCount.textContent = 0;
}
function saveTasks() {
  localStorage.setItem("tasks", JSON.stringify(tasks));
}
function loadTasks() {
  const raw = localStorage.getItem("tasks");

  try {
    tasks = raw ? JSON.parse(raw) : [];
  } catch (error) {
    console.error("LocalStorage verisi okunamadı:", error);

    tasks = [];

    localStorage.removeItem("tasks");
  }

  renderTasks(tasks);
}
async function loadSampleTasks() {
  message.textContent = "Yükleniyor...";
  try {
    const response = await fetch("./data/tasks.json");

    if (!response.ok) {
      throw new Error("Örnek görevler yüklenemedi.");
    }

    const sampleTasks = await response.json();

    sampleTasks.forEach((sampleTask) => {
      const exists = tasks.find((task) => task.id === sampleTask.id);

      if (!exists) {
        tasks.push(sampleTask);
      }
    });

    saveTasks();
    message.textContent = "Örnek görevler başarıyla yüklendi.";

    applyFilters();
  } catch (error) {
    message.textContent = error.message;

    console.error(error);
  }
}

function updateEmptyState() {
  if (tasks.length === 0) {
    emptyState.hidden = false;
  } else {
    emptyState.hidden = true;
  }
}

function applyFilters() {
  const status = statusFilter.value;
  const priority = priorityFilter.value;

  let filteredTasks = tasks;

  if (status !== "all") {
    filteredTasks = filteredTasks.filter((task) => task.status === status);
  }

  if (priority !== "all") {
    filteredTasks = filteredTasks.filter((task) => task.priority === priority);
  }

  renderTasks(filteredTasks);
}

statusFilter.addEventListener("change", function () {
  applyFilters();
});

tableBody.addEventListener("click", function (event) {
  if (!event.target.classList.contains("complete-btn")) return;

  const id = Number(event.target.dataset.id);

  const task = tasks.find((task) => task.id === id);

  if (!task) return;

  task.status = "done";

  saveTasks();

  applyFilters();
});
priorityFilter.addEventListener("change", function () {
  applyFilters();
});

if (!localStorage.getItem("tasks")) {
  tasks.push(
    {
      id: 1,
      title: "HTML Formları",
      priority: "high",
      status: "open",
      createdAt: "10.07.2026",
    },
    {
      id: 2,
      title: "CSS Düzeni",
      priority: "normal",
      status: "open",
      createdAt: "10.07.2026",
    },
    {
      id: 3,
      title: "JavaScript Başlangıç",
      priority: "low",
      status: "done",
      createdAt: "10.07.2026",
    },
  );

  saveTasks();
}

loadTasks();
loadSampleBtn.addEventListener("click", function () {
  loadSampleTasks();
});
clearStorageBtn.addEventListener("click", function () {
  localStorage.removeItem("tasks");

  tasks = [];

  renderTasks(tasks);

  message.textContent = "Görevler temizlendi.";
});
