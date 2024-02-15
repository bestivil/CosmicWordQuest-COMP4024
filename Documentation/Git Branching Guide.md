# Branch Conventions

### main

The main branch of the repository, represents the current "version" of the game. What will be presented in the end. Tests should pass and bugs should be minimised before merges happen to this branch. Prioritise it to be stable 

### dev

The development branch for this project. Central hub for all devs to integrate new features, bug fixes etc. Make changes here instead of directly into main branch.

Each week the dev branch should be reviewed and merged into main to keep main updated with development

both main and dev should be protected

**Code reviews** through pull requests should make sure the code pushed to these branches is reviewed, and any improvements and suggestions are put in place before merging happens
- at least **2 people need to review** a pull request into the dev branch

### feature branches

Used for each ticket/issue on Trello/Git

Each dev makes a new branch for that issue, adds new features etc and in the end creates a **pull request** into the dev branch that will then get code reviewed

The naming conventions 
- the branch should follow the name of the corresponding **issue** on GitHub

to create the branch:
1. copy the name of the issue on GitHub in the "Development" section of the issue
2. use `git branch` to create the branch
3. once the work is done, use `git push` or `git push --set-upstream origin <branch_name>` if this is the first push to create the corresponding remote branch 