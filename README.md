more information please visit the following link:
http://justinramel.com/2012/09/17/jenkins-dot-net/


1, download http://jenkins-ci.org/

```
 java -jar jenkins.war
```
OR

running it on tomcat, simply copy jenkins.war to $TOMCAT_HOME/webapps, then access http://yourhost/jenkins.
refer: https://wiki.jenkins-ci.org/display/JENKINS/Tomcat

setup the environment JENKINS_HOME to "/yourpath/.jenkins"

2, access http://localhost:8080/pluginManager/

Required Plugins:

* GitHub Plugin - This plugin integrates Jenkins with Github projects.

Build Plugins
* MSBuild Plugin - This plugin allows you to use MSBuild to build .NET projects.

Testing Plugins
* MSTest Plugin - This plugin converts MSTest TRX test reports into JUnit XML reports so it can be integrated with Jenkins JUnit features.
* NUnit Plugin - This plugin allows you to publish NUnit test results.
* xUnit Plugin - This plugin makes it possible to publish the test results of an execution of a testing tool in Jenkins.
* Gallio Plugin - This plugin makes it possible to publish Gallio/MbUnit test results.

Code Analysis
* Task Scanner Plugin - This plugin scans the workspace files for open tasks and generates a trend report.
* Warnings Plugin - This plugin generates the trend report for compiler warnings in the console log or in log files.


3, setup msbuild
* http://localhost:8080/configure
* add msbuild

4, new job
* http://localhost:8080/newJob
* Source Code Management
	* git
	* Build when a change is pushed to Github
	* Poll SCM, such as: H/2 * * * *
* build triggers -> Build when a change is pushed to GitHub
* build 
	* select msbuild version
	* msbuild build file (ci.msbuild)
* post-build
	* MSTest(or any other unit test plugin)
		* Test report TRX file: **/TestResults.xml
	* email-notification
	* scan for compiler warnings
		* Scan console log > Parser > MSBuild
    * Scan workspace for open tasks
    	* In the “Files to scan” textbox enter: **/*.cs which scans all C Sharp files for these comments.
		* In the “Tasks tags” High priority textbox enter: HACK, FIXME
		* In the “Tasks tags” Normal priority textbox enter: TODO, TO-DO
		* Tick the “Ignore case” check box

5, security
* go to http://localhost:8080/configureSecurity/
* enable security
* sign up first user 



