console.log("TaskBoard JavaScript yüklendi.");

const form = document.querySelector("#task-form");
const titleInput = document.querySelector("#task-title");
const prioritySelect = document.querySelector("#priority");
const tableBody = document.querySelector("#task-table-body");
const totalCount = document.querySelector("#total-count");
const openCount = document.querySelector("#open-count");
const emptyState = document.querySelector(".empty-state");

form.addEventListener("submit", function (event) {
  event.preventDefault();

  const title = titleInput.value.trim();
  const priority = prioritySelect.value;

  if (!title) {
    return;
  }
  let priorityText = "";
  let priorityClass = "";

  if (priority === "high") {
    priorityText = "Yüksek";
    priorityClass = "high";
  } else if (priority === "normal") {
    priorityText = "Normal";
    priorityClass = "normal";
  } else {
    priorityText = "Düşük";
    priorityClass = "low";
  }

  tableBody.insertAdjacentHTML(
    "beforeend",
    `
      <tr>
        <td>${title}</td>
        <td><span class="badge ${priorityClass}">${priorityText}</span></td>
        <td><span class="status status-open">Açık</span></td>
        <td>${new Date().toLocaleDateString("tr-TR")}</td>
      </tr>
    `,
  );
  totalCount.textContent = Number(totalCount.textContent) + 1;
  openCount.textContent = Number(openCount.textContent) + 1;

  form.reset();
  titleInput.focus();

  updateEmptyState();
});
function updateEmptyState() {
  if (tableBody.rows.length === 0) {
    emptyState.hidden = false;
  } else {
    emptyState.hidden = true;
  }
}
updateEmptyState();
