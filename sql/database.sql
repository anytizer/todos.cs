-- DROP DATABASE IF EXISTS awesome_todos;
-- CREATE DATABASE awesome_todos CHARACTER SET utf8 COLLATE utf8_general_ci;
-- USE awesome_todos;

-- SHOW CREATE TABLE todo_users;
DROP TABLE IF EXISTS todo_users;
CREATE TABLE `todo_users` (
  `user_id` VARCHAR(255) NOT NULL COMMENT 'User ID',
  `user_username` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'User Name',
  `user_password` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'User Password',
  `user_fullname` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Full name',
  `is_active` ENUM('N','Y') NOT NULL DEFAULT 'N' COMMENT 'Active user?',
  `added_on` DATETIME NOT NULL COMMENT 'Added On',
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `username_key` (`user_username`)
);

-- SHOW CREATE TABLE todo_projects;
DROP TABLE IF EXISTS todo_projects;
CREATE TABLE `todo_projects` (
  `project_id` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'GUID Value',
  `project_name` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Project Name',
  `is_active` ENUM('N','Y') NOT NULL DEFAULT 'N' COMMENT 'Is active?',
  `added_on` DATETIME NOT NULL COMMENT 'Added On',
  PRIMARY KEY (`project_id`)
);

-- SHOW CREATE TABLE todo_users_projects;
DROP TABLE IF EXISTS todo_users_projects;
CREATE TABLE `todo_users_projects` (
  `user_id` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'User ID',
  `project_id` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Project ID',
  `added_on` DATETIME NOT NULL COMMENT 'Added On',
  PRIMARY KEY (`user_id`,`project_id`),
  KEY `project_id` (`project_id`),
  CONSTRAINT `todo_users_projects_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `todo_users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `todo_users_projects_ibfk_2` FOREIGN KEY (`project_id`) REFERENCES `todo_projects` (`project_id`) ON DELETE CASCADE ON UPDATE CASCADE
);

-- SHOW CREATE TABLE todo_statuses;
DROP TABLE IF EXISTS todo_statuses;
CREATE TABLE `todo_statuses` (
  `status_id` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'GUID Value',
  `status_code` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Status Code',
  `status_shortname` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Short Name',
  `status_name` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Status Full Name',
  `is_active` ENUM('N','Y') NOT NULL DEFAULT 'N' COMMENT 'Is Active?',
  `in_menu` ENUM('N','Y') NOT NULL DEFAULT 'N' COMMENT 'Show in Context Menu?',
  `in_list` ENUM('N','Y') NOT NULL DEFAULT 'N' COMMENT 'Show in List?',
  `status_priority` INT(10) UNSIGNED NOT NULL DEFAULT '0' COMMENT 'Sorting Priority',
  `status_color` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Banding Color',
  PRIMARY KEY (`status_id`)
);

-- SHOW CREATE TABLE todo_todos;
DROP TABLE IF EXISTS todo_todos;
CREATE TABLE `todo_todos` (
  `todo_id` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'GUID Value',
  `issue_number` VARCHAR(255) NOT NULL DEFAULT '' COMMENT 'Issue Number',
  `todo_text` TEXT NOT NULL COMMENT 'Todo Text',
  `is_active` ENUM('N','Y') NOT NULL DEFAULT 'N' COMMENT 'Active?',
  PRIMARY KEY (`todo_id`)
);

-- SHOW CREATE TABLE todo_todos_statuses;
DROP TABLE IF EXISTS todo_todos_statuses;
CREATE TABLE `todo_todos_statuses` (
  `todo_status_id` VARCHAR(255) NOT NULL COMMENT 'ToDo Status ID',
  `todo_id` VARCHAR(255) NOT NULL COMMENT 'ToDo ID',
  `status_id` VARCHAR(255) NOT NULL COMMENT 'Status ID',
  `added_on` DATETIME NOT NULL COMMENT 'Added On',
  `is_latest` ENUM('N','Y') NOT NULL COMMENT 'Only one per ToDo',
  PRIMARY KEY (`todo_status_id`),
  KEY `todo_id` (`todo_id`),
  KEY `status_id` (`status_id`),
  CONSTRAINT `todo_todos_statuses_ibfk_1` FOREIGN KEY (`todo_id`) REFERENCES `todo_todos` (`todo_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `todo_todos_statuses_ibfk_2` FOREIGN KEY (`status_id`) REFERENCES `todo_statuses` (`status_id`) ON DELETE CASCADE ON UPDATE CASCADE
);

-- SHOW CREATE TABLE todo_todos_statuses;
DROP TABLE IF EXISTS todo_todos_statuses;
CREATE TABLE `todo_todos_statuses` (
  `todo_status_id` VARCHAR(255) NOT NULL,
  `todo_id` VARCHAR(255) NOT NULL COMMENT 'ToDo ID',
  `status_id` VARCHAR(255) NOT NULL COMMENT 'Status ID',
  `added_on` DATETIME NOT NULL COMMENT 'Added On',
  `is_latest` ENUM('N','Y') NOT NULL COMMENT 'Only one per ToDo',
  PRIMARY KEY (`todo_status_id`),
  KEY `todo_id` (`todo_id`),
  KEY `status_id` (`status_id`),
  CONSTRAINT `todo_todos_statuses_ibfk_1` FOREIGN KEY (`todo_id`) REFERENCES `todo_todos` (`todo_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `todo_todos_statuses_ibfk_2` FOREIGN KEY (`status_id`) REFERENCES `todo_statuses` (`status_id`) ON DELETE CASCADE ON UPDATE CASCADE
);