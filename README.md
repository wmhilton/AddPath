AddPath
=======

AddPath.exe takes a directory and appends it to the Path env. variable

*Usage:*

AddPath  [options] [path]

[options] can be zero or more of:

-p    only change path in process

-m    change path on machine (default)

-u    change path for user

[path] directory you want to add to the path environment variable

TODO
----
At some point, I'd like to automate the installation process described in [Jason Rowe's  post](http://jasonrowe.com/2012/04/25/right-click-add-to-path/) i.e.

    HKEY_CLASSES_ROOT\Folder\shell\Add Folder to System Path\command = C:\tools\AddPath.exe -m "%1"
    HKEY_CLASSES_ROOT\Folder\shell\Add Folder to User Path\command = C:\tools\AddPath.exe -u "%1"
