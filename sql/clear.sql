DELETE FROM `todo_todos_statuses`;
DELETE FROM `todo_users_projects`;
DELETE FROM `todo_projects_todos`;
DELETE FROM `todo_todos`;

INSERT INTO `todo_users_projects` VALUES('C50EF177-16A1-4B0C-A8EA-5F985355E7A1', '6F39DA75-EE09-44EA-80DB-23087F0C555D', NOW());