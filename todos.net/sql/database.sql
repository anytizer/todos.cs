SHOW CREATE TABLE todo_statuses;
CREATE TABLE `todo_statuses` (
  `status_id` VARCHAR(255) NOT NULL DEFAULT '',
  `status_name` VARCHAR(255) NOT NULL DEFAULT '',
  `status_code` VARCHAR(255) DEFAULT '',
  PRIMARY KEY (`status_id`)
);

SHOW CREATE TABLE todo_projects;
CREATE TABLE `todo_projects` (
  `project_id` VARCHAR(255) NOT NULL DEFAULT '',
  `project_name` VARCHAR(255) NOT NULL DEFAULT '',
  PRIMARY KEY (`project_id`)
);

SHOW CREATE TABLE todo_todo;
CREATE TABLE `todo_todo` (
  `todo_id` VARCHAR(255) NOT NULL DEFAULT '',
  `project_id` VARCHAR(255) NOT NULL DEFAULT '',
  `status_id` VARCHAR(255) NOT NULL DEFAULT '',
  `added_on` DATETIME NOT NULL,
  `todo_text` TEXT NOT NULL,
  PRIMARY KEY (`todo_id`),
  KEY `project_id` (`project_id`),
  KEY `status_id` (`status_id`),
  CONSTRAINT `todo_todo_ibfk_1` FOREIGN KEY (`project_id`) REFERENCES `todo_projects` (`project_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `todo_todo_ibfk_2` FOREIGN KEY (`status_id`) REFERENCES `todo_statuses` (`status_id`) ON DELETE CASCADE ON UPDATE CASCADE
);

DROP VIEW IF EXISTS v_todo;
CREATE VIEW v_todo AS
SELECT
	t.todo_id,
	p.project_id, p.project_name,
	s.status_id, s.status_name,
	t.added_on, t.todo_text
FROM todo_todo t
INNER JOIN todo_projects p ON p.project_id = t.project_id
INNER JOIN todo_statuses s ON s.status_id = t.status_id
;