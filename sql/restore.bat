@echo off
echo Are you sure?
pause
pause
mysql -uroot awesome_todos todo_statuses < status.dmp
