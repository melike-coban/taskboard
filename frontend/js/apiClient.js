const API_URL = "http://localhost:5063/api/tasks";

async function request(url, options = {}) {
  const response = await fetch(url, {
    headers: {
      "Content-Type": "application/json",
    },
    ...options,
  });

  if (!response.ok) {
    throw new Error("İşlem başarısız oldu.");
  }

  if (response.status === 204) {
    return null;
  }

  return await response.json();
}

const taskApi = {
  getTasks() {
    return request(API_URL);
  },

  createTask(task) {
    return request(API_URL, {
      method: "POST",
      body: JSON.stringify(task),
    });
  },

  updateTask(id, task) {
    return request(`${API_URL}/${id}`, {
      method: "PUT",
      body: JSON.stringify(task),
    });
  },

  deleteTask(id) {
    return request(`${API_URL}/${id}`, {
      method: "DELETE",
    });
  },
  deleteAllTasks() {
    return request(API_URL, {
      method: "DELETE",
    });
  },
};
