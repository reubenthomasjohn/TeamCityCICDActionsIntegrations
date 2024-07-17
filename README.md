### Walkthrough of the [Windows App pipeline](.github/workflows/iis-deploy-winforms.yaml).

1. `on`: Describes the github event for which the pipeline needs to be triggered. Here, there are two conditions which need to be satisfied:
   a. A push event to the main branch.
   b. Code changes only in the WindowsFormsApp/ directory.

2. `jobs`: Describes the steps involved in the pipeline. There are a number of jobs in this pipeline, which are run on an ubuntu machine.
   This is specified by the `deploy` and `runs-on` durectives.

   a. Checkout repository - Takes the latest code from the main branch. \
   b. Install Mono - A package used to support building of dotnet framework projects on ubuntu systems. \
   c. Restore NuGet packages - Restore all the dependencies required for the project. \
   d. Build the project - Run the `msbuild` command to build the project. \
   e. Install `expect` - this is a library that is required to SSH into the Windows Server machine. \
   f,g. Create SSH directory and known_hosts file - We are creating a known_hosts file and adding the SSH key of our Windows server into the known hosts of the runner provisioned by Github. \
   h. Take Backup - After SSHing into the Windows server system, use xcopy to copy the existing built files from inetpub\wwwroot\WinFormsApp to the Backup folder.
   i. Deploy - A custom scripts used to `scp` our built files into our host machine. \
