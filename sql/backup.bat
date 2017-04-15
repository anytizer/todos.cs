@echo off
mysqldump -uroot awesome_todos todo_statuses > status.dmp
mysqldump -uroot --routines awesome_todos > full.dmp