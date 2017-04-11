DROP VIEW IF EXISTS v_todos;
CREATE VIEW v_todos AS
SELECT
	t.todo_id,
	p.project_id,
	s.status_id,
	t.added_on,
	
	t.issue_number,
	p.project_name,
	s.status_name,
	t.todo_text
FROM todo_todos t
INNER JOIN todo_projects p ON t.project_id = p.project_id
INNER JOIN todo_statuses s ON t.status_id = s.status_id
ORDER BY
	s.status_priority DESC
;

SELECT * FROM v_todos v
WHERE
	v.project_id="640bc432-cdff-4b7d-8d04-c418cd989aa3"
	AND v.status_id="e827c910-5235-4c87-9f13-daf960682d54"
ORDER BY
	added_on DESC
;

SELECT * FROM todo_todos WHERE todo_id='24a93e76-a675-4ad4-9d8f-0bc975249cae';