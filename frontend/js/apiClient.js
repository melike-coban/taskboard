const API_URL = "http://localhost:5063/api/tasks";

async function request(url, options = {}) {
  const response = await fetch(url, {
    headers: {
      "Content-Type": "application/json",
    },
    credentials: "include",
    ...options,
  });

  if (!response.ok) {
    let errorMessage = "İşlem başarısız oldu.";

    try {
      const error = await response.json();

      if (error.message) {
        errorMessage = error.message;
      }
    } catch {}

    throw new Error(errorMessage);
  }

  if (response.status === 204) {
    return null;
  }

  return await response.json();
}

const taskApi = {
  getTasks(query = {}) {
    const params = new URLSearchParams();

    if (query.search) {
      params.append("search", query.search);
    }

    if (query.status && query.status !== "all") {
      params.append("status", query.status);
    }

    if (query.priority && query.priority !== "all") {
      params.append("priority", query.priority);
    }

    params.append("page", query.page || 1);
    params.append("pageSize", query.pageSize || 10);

    return request(`${API_URL}?${params.toString()}`);
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
  markAsDone(id) {
    return request(`${API_URL}/${id}/done`, {
      method: "PATCH",
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
