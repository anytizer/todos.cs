-- SHOW CREATE VIEW v_statuses;
DROP VIEW IF EXISTS v_statuses;
CREATE VIEW v_statuses AS
-- EXPLAIN
SELECT
	u.user_id,
	s.status_name,
	COUNT(s.status_id) total
FROM todo_todos t
INNER JOIN todo_todos_statuses ts ON ts.todo_id = t.todo_id
INNER JOIN todo_statuses s ON s.status_id = ts.status_id
INNER JOIN todo_projects_todos pd ON pd.todo_id = t.todo_id
INNER JOIN todo_projects p ON p.project_id = pd.project_id
INNER JOIN todo_users_projects up ON p.project_id = up.project_id
INNER JOIN todo_users u ON u.user_id = up.user_id
WHERE
	t.is_active='Y'
	AND s.is_active='Y'
	AND s.in_list='Y'
	AND ts.is_latest='Y'
GROUP BY
	s.status_id
ORDER BY
	s.status_priority
;

SELECT * FROM v_statuses WHERE user_id='C50EF177-16A1-4B0C-A8EA-5F985355E7A1';