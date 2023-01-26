# TaskManagmentAPI

Task Description:
Implement an API that allows a user to create and manage a list of tasks. The API should have
the following functionality:
• Creating a task: A user should be able to create a new task by making a POST request to
the API with the task's title, start date and end date. The API should validate the request
payload and return a response indicating whether the task was created successfully.
• Retrieving tasks: A user should be able to retrieve their list of tasks by making a GET
request to the API. The API should return a list of all tasks, sorted by due date and
Paginated.
• Updating a task: A user should be able to update a task by making a PUT request to the
API with the task's ID and any updated information (e.g., title, start date, end date). The
API should validate the request payload and return a response indicating whether the
update was successful.
• Deleting a task: A user should be able to delete a task by making a DELETE request to
the API with the task's ID. The API should return a response indicating whether the
delete was successful.
• import endpoint: the user should be apple to upload a csv file where each row contains
three columns that represent the task title , start date and end date respectively, and insert
that to the system database.
Validation Rules:
• the task title should be unique
• there should not be any overlapping tasks
