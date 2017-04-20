/*
-- SELECT * FROM v_todos;

 p.project_id = pd.project_id
 s.status_id = ts.status_id
 
`awesome_todos`
WHERE
	v.project_id="640bc432-cdff-4b7d-8d04-c418cd989aa3"
	AND v.status_id="e827c910-5235-4c87-9f13-daf960682d54"
ORDER BY
	added_on DESC
;
-- UPDATE todo_todos SET is_active='Y';

SELECT * FROM todo_todos WHERE todo_id='24a93e76-a675-4ad4-9d8f-0bc975249cae';
*/

INSERT INTO todo_projects_todos SELECT 'E827C910-5235-4C87-9F13-DAF960682D51', todo_id, NOW() FROM todo_todos;