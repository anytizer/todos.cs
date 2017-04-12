-- DROP DATABASE IF EXISTS awesome_todos;
-- CREATE DATABASE awesome_todos CHARACTER SET utf8 COLLATE utf8_general_ci;
-- USE awesome_todos;

-- SHOW CREATE TABLE todo_statuses;
DROP TABLE IF EXISTS todo_statuses;
CREATE TABLE `todo_statuses` (
  `status_id` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'GUID Value',
  `status_code` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Status Code',
  `status_shortname` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Short Name',
  `status_name` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Status Full Name',
  `status_priority` INT(10) UNSIGNED NOT NULL DEFAULT '0' COMMENT 'Sorting Priority',
  PRIMARY KEY (`status_id`)
);

-- SHOW CREATE TABLE todo_projects;
DROP TABLE IF EXISTS todo_projects;
CREATE TABLE `todo_projects` (
  `project_id` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'GUID Value',
  `project_name` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Project Name',
  `is_active` ENUM('N','Y') DEFAULT 'N' COMMENT 'Is active?',
  PRIMARY KEY (`project_id`)
);

-- SHOW CREATE TABLE todo_todos;
DROP TABLE IF EXISTS todo_todos;
CREATE TABLE `todo_todos` (
  `todo_id` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'GUID Value',
  `project_id` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Project ID',
  `status_id` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Status ID',
  `issue_number` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Issue Number',
  `todo_text` TEXT NOT NULL COMMENT 'Todo Text',
  `added_on` DATETIME NOT NULL COMMENT 'Added On',
  `modified_on` DATETIME NOT NULL COMMENT 'Modified On',
  `is_active` ENUM('N','Y') NOT NULL DEFAULT 'N' COMMENT 'Active?',
  PRIMARY KEY (`todo_id`),
  KEY `project_id` (`project_id`),
  KEY `status_id` (`status_id`),
  CONSTRAINT `todo_todos_ibfk_1` FOREIGN KEY (`project_id`) REFERENCES `todo_projects` (`project_id`),
  CONSTRAINT `todo_todos_ibfk_2` FOREIGN KEY (`status_id`) REFERENCES `todo_statuses` (`status_id`)
);

-- SHOW CREATE TABLE todo_projects_statuses;
DROP TABLE IF EXISTS todo_projects_statuses;
CREATE TABLE `todo_projects_statuses` (
  `history_id` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'History ID',
  `project_id` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Project ID',
  `status_id` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Status ID',
  `modified_on` DATETIME NOT NULL COMMENT 'Modified On',
  PRIMARY KEY (`history_id`),
  KEY `project_id` (`project_id`),
  KEY `status_id` (`status_id`),
  CONSTRAINT `todo_projects_statuses_ibfk_1` FOREIGN KEY (`project_id`) REFERENCES `todo_projects` (`project_id`),
  CONSTRAINT `todo_projects_statuses_ibfk_2` FOREIGN KEY (`status_id`) REFERENCES `todo_statuses` (`status_id`)
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
ORDER BY
	s.status_priority
;
-- SELECT * FROM v_todos;
