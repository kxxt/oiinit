@echo off
color F4
:loop
	mkdata
	#REPLACE#
	_#REPLACE#
	fc #REPLACE#.out _#REPLACE#.out
	if errorlevel == 1 pause
goto loop