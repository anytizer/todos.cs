-- DROP DATABASE IF EXISTS awesome_todos;
-- CREATE DATABASE awesome_todos CHARACTER SET utf8 COLLATE utf8_general_ci;
-- USE awesome_todos;

-- SHOW CREATE TABLE todo_statuses;
DROP TABLE IF EXISTS todo_statuses;
CREATE TABLE todo_statuses (
  status_id VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'GUID',
  status_code VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Status Code',
  status_name VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Status Name',
  status_priority INT(10) NOT NULL DEFAULT '0' COMMENT 'Sorting Priority',
  PRIMARY KEY (status_id)
);

-- SHOW CREATE TABLE todo_projects;
DROP TABLE IF EXISTS todo_projects;
CREATE TABLE todo_projects (
  project_id VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'GUID',
  project_name VARCHAR(255) NOT NULL DEFAULT '',
  is_active ENUM('N','Y') DEFAULT 'N',
  PRIMARY KEY (project_id)
);

-- SHOW CREATE TABLE todo_todos;
DROP TABLE IF EXISTS todo_todos;
CREATE TABLE todo_todos (
  todo_id VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'GUID',
  project_id VARCHAR(255) NOT NULL DEFAULT '',
  status_id VARCHAR(255) NOT NULL DEFAULT '',
  issue_number VARCHAR(255) NOT NULL DEFAULT '',
  todo_text TEXT NOT NULL,
  added_on DATETIME NOT NULL,
  modified_on DATETIME NOT NULL,
  is_active ENUM('N','Y') NOT NULL DEFAULT 'N',
  PRIMARY KEY (todo_id),
  KEY project_id (project_id),
  KEY status_id (status_id),
  CONSTRAINT todo_todos_ibfk_1 FOREIGN KEY (project_id) REFERENCES todo_projects (project_id),
  CONSTRAINT todo_todos_ibfk_2 FOREIGN KEY (status_id) REFERENCES todo_statuses (status_id)
);

-- SHOW CREATE VIEW v_todos;
DROP VIEW IF EXISTS v_todos;
CREATE VIEW v_todos AS
SELECT
	t.todo_id,
	p.project_id, p.project_name,
	s.status_id, s.status_name,
	t.added_on, t.todo_text
FROM todo_todos t
INNER JOIN todo_projects p ON p.project_id = t.project_id
INNER JOIN todo_statuses s ON s.status_id = t.status_id
WHERE
	t.is_active='Y'
;
-- SELECT * FROM v_todos;
