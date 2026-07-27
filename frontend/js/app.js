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
const searchInput = document.querySelector("#search-input");
const totalRecords = document.querySelector("#total-records");
const pageInfo = document.querySelector("#page-info");

let tasks = [];

form.addEventListener("submit", async function (event) {
  event.preventDefault();

  const title = titleInput.value.trim();
  const priority = prioritySelect.value;

  if (!title) return;

  try {
    await taskApi.createTask({
      title: title,
      priority: priority,
      description: "",
    });

    await loadTasks();

    message.textContent = "Görev başarıyla eklendi.";
  } catch (error) {
    message.textContent = error.message;
  }

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

      if (task.status === "Open") {
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

  <button class="btn delete-btn" data-id="${task.id}">
    Sil
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

  openCount.textContent = tasks.filter((task) => task.status === "Open").length;

  doneCount.textContent = tasks.filter((task) => task.status === "Done").length;

  // Şimdilik "Devam Eden" bilgisi backend'de olmadığı için 0 bırakıyoruz.
  progressCount.textContent = 0;
}
function saveTasks() {
  localStorage.setItem("tasks", JSON.stringify(tasks));
}
async function loadTasks() {
  try {
    const response = await taskApi.getTasks({
      search: searchInput.value,
      status: statusFilter.value,
      priority: priorityFilter.value,
      page: 1,
      pageSize: 10,
    });

    tasks = response.items;

    totalRecords.textContent = `Toplam kayıt: ${response.totalCount}`;

    pageInfo.textContent = `Sayfa ${response.page} / ${response.totalPages}`;

    renderTasks(tasks);
  } catch (error) {
    console.error(error);
    message.textContent = "Görevler yüklenemedi.";
  }
}
async function loadSampleTasks() {
  message.textContent = "Yükleniyor...";
  try {
    const response = await fetch("./data/tasks.json");

    if (!response.ok) {
      throw new Error("Örnek görevler yüklenemedi.");
    }

    const sampleTasks = await response.json();

    for (const sampleTask of sampleTasks) {
      await taskApi.createTask({
        title: sampleTask.title,
        priority: sampleTask.priority,
      });
    }

    await loadTasks();

    message.textContent = "Örnek görevler başarıyla yüklendi.";
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

statusFilter.addEventListener("change", loadTasks);

priorityFilter.addEventListener("change", loadTasks);
searchInput.addEventListener("input", loadTasks);

tableBody.addEventListener("click", async function (event) {
  const id = Number(event.target.dataset.id);

  if (event.target.classList.contains("delete-btn")) {
    if (!confirm("Bu görevi silmek istediğinize emin misiniz?")) {
      return;
    }

    try {
      await taskApi.deleteTask(id);
      await loadTasks();
      message.textContent = "Görev silindi.";
    } catch (error) {
      message.textContent = error.message;
    }

    return;
  }

  if (event.target.classList.contains("complete-btn")) {
    try {
      await taskApi.markAsDone(id);

      await loadTasks();

      message.textContent = "Görev tamamlandı.";
    } catch (error) {
      message.textContent = error.message;
    }
  }
});

loadTasks();
loadSampleBtn.addEventListener("click", function () {
  loadSampleTasks();
});
clearStorageBtn.addEventListener("click", async function () {
  if (!confirm("Tüm görevleri silmek istediğinize emin misiniz?")) {
    return;
  }

  try {
    await taskApi.deleteAllTasks();

    await loadTasks();

    message.textContent = "Tüm görevler silindi.";
  } catch (error) {
    console.error(error);
    message.textContent = error.message;
  }
});
