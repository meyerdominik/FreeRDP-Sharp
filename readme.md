**C# wrapper around FreeRDP**

It can make connection to RDP session, but it is not drawing anything on the screen. Only commands to draw are exposed.

It uses FreeRDP version from branch stable-1.1

**Git config**
If you are on windows please use:
`git config  core.autocrlf true`
to properly handle end of line conversion because files are commited in unix eol format.
Also there is .editorcong which sets editor to use tabs by default because files in the repo are using it.
