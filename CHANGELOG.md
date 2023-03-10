# Changelog

All changes to this module should be reflected in this document.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [[1.1.0]](https://github.com/PoshAdoTasks/PoshAdoTask/releases/tag/v1.1.0) - 2023-01-10

This release fixes some issues discovered while attempting to use the module in production.

Issues Addressed:

1. tfx cli is case-sensitive, manifest.repository.type git <> Git (issue #3)
   1. Changed Repository.Type to String
   2. Updated New-Repository to pass in lowercase cvs,git,mercurial,svn
2. Contribution.Property.Name is not arbitrary (issue #4)
   1. Updated the Add-Contribution to accept -Name
3. Manifest.Version is a string, Task.Version is essentially a System.Version object
   1. Created a new cmdlet to set the version (New-Version)

--

## [[1.0.0]](https://github.com/PoshAdoTasks/PoshAdoTask/releases/tag/v1.0.0) - 2023-01-09

This is the initial release of this module, the goal is to provide a set of tools for working with and developing Azure Devops Extensions as quickly and easily as possible. There are two Types that we work with Manifest and Task, each of these are used in developing the extension.

You can find the documentation for the Extension Manifest [here](https://learn.microsoft.com/en-us/azure/devops/extend/develop/manifest?view=azure-devops#discoveryprops)

You can find the documentation for the Task Refernce [here](https://github.com/Microsoft/azure-pipelines-task-lib/blob/master/tasks.schema.json)

From there I built out an initial set of cmdlets based on what you would find in a typical vss-extension.json and task.json.

--
