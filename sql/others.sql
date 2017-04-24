UPDATE todo_todos_statuses SET todo_status_id=todo_id;

-- crate project todos
INSERT INTO todo_projects_todos (project_id, todo_id, added_on) SELECT '6F39DA75-EE09-44EA-80DB-23087F0C555D' project_id, todo_id, NOW() FROM todo_todos;

-- create todos status
INSERT INTO todo_todos_statuses SELECT UUID(), 'C50EF177-16A1-4B0C-A8EA-5F985355E7A1' user_id, todo_id, 'E827C910-5235-4C87-9F13-DAF960682D51' status_id, NOW(), 'Y' FROM todo_todos

SELECT MD5(CONCAT(RAND(), RAND()));
SELECT INSERT(MD5(CONCAT(RAND(), RAND())), 8, 1, '-');
-- C50EF177-16A1-4B0C-A8EA-5F985355E7A1
-- 11fa52baa9389a8739afc5e9b7adeec6
SELECT UUID()


-- projects of a user
SELECT
	* FROM `todo_projects_todos`
FROM
WHERE
; 

SELECT * FROM todo_users WHERE user_username='user1';