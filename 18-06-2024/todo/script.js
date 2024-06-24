$(document).ready(function () {
  // Load tasks from localStorage on page load
  loadTasks();

  // Handle form submission
  $("#todo-form").submit(function (event) {
    event.preventDefault();
    var task = $("#todo-input").val();
    if (task) {
      addTask(task);
      saveTasks();
      $("#todo-input").val("");
    }
  });

  //  add a new task
  function addTask(task) {
    var li = $("<li>").html(`<span>${task}</span>`);
    console.log(li);
    var deleteButton = $("<button>").text("Delete").addClass("delete");
    li.append(deleteButton);
    $("#todo-list").append(li);
  }

  //  save tasks to localStorage
  function saveTasks() {
    var tasks = [];
    $("#todo-list li").each(function () {
      console.log($(this).text());
      tasks.push($(this).text());
    });
    localStorage.setItem("tasks", JSON.stringify(tasks));
  }

  // load tasks from localStorage
  function loadTasks() {
    var tasks = JSON.parse(localStorage.getItem("tasks")) || [];
    tasks.forEach(function (task) {
      addTask(task);
    });
  }

  // delete
  $("#todo-list").on("click", ".delete", function (event) {
    $(this).parent().remove();
    saveTasks();
  });
});
