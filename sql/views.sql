-- SHOW CREATE VIEW v_todos;
DROP VIEW IF EXISTS v_todos;
CREATE VIEW v_todos AS
SELECT
	t.todo_id,
	p.project_id, p.project_name,
	s.status_id, s.status_shortname status_name,
	t.added_on, t.issue_number, t.todo_text
FROM todo_todos t
INNER JOIN todo_projects p ON p.project_id = t.project_id
INNER JOIN todo_statuses s ON s.status_id = t.status_id
WHERE
	t.is_active='Y'
	AND s.is_active='Y'
	AND s.in_list='Y'
ORDER BY
	s.status_priority
;
-- SELECT * FROM v_todos;

SELECT * FROM v_todos v
WHERE
	v.project_id="640bc432-cdff-4b7d-8d04-c418cd989aa3"
	AND v.status_id="e827c910-5235-4c87-9f13-daf960682d54"
ORDER BY
	added_on DESC
;
UPDATE todo_todos SET is_active='Y';

SELECT * FROM todo_todos WHERE todo_id='24a93e76-a675-4ad4-9d8f-0bc975249cae';