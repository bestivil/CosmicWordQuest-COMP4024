## Git clone instructions

Use clone to initialise the local repository or, in cases where it is far behind from the main branch, to re-clone it to be upto date with main and (this will disgard your local changes however, so if you have them make a push first)  

1. go to the green button on the main GitHub page where it says "Code"

![image](https://github.com/bestivil/COMP4024-G13/assets/106749356/3c4e261c-21bd-47a3-95fd-b0584050f501)

2. Copy the HTTPS url string and run this command in your terminal
   `git clone <string>`

## Git main branch being out-of-date 

This issue happens a lot with our repository due to Unity files etc. changing quickly

Sometimes git pull on main branch will not work if the local one is too out-of-date, so the following commands should reset the local one to be exactly like the remote main branch

1. `git fetch`
2. `git reset origin/main —hard`
3. `git pull origin main`

this will however override your local changes made to the main branch, so make sure that those are commited(if they are needed to be pushed i.e. you have done meaningful work that should be in the remote repo)
## Git commit instructions

### Git commit to new branch

Follow this if you are making a commit to a new branch you've created

1. **Update** your local repository to be the same as the remote repository

	`git fetch`
	`git pull`

2.  Make the code changes that you wanted to make
3. Make a new branch and follow the branching coding conventions(link here) and make sure it is checkout out

	`git checkout -b <feature_branch_name>`


4. **Stage** your changes 

	`git add <file>`
	or
	`git add .` to add all files

5. **Commit** your changes to this new branch while following the commit conventions(link here)

6. Update your local repository again to make sure it is up-to-date as someone could've pushed meanwhile doing your work
`git pull`
If a merge conflict happens, go to "Resolving Conflicts" below

7. **Push** your changes on this new branch

	`git push origin <feature_branch_name>`

The branch should now be visible on the GitLab repo
When you are ready create a **pull request** to make a merge into the dev branch. Follow "Pull requests" below

## Updating an existing branch

This is when you want to make **more changes** to an already existing branch on the repository

1. Make sure you are on the correct feature branch
	`git checkout <feature_branch_name>`

#### making major changes
This is for when you add a new file or make major changes to some file(s) e.g. new classes and functions

2. **Stage, commit and push** exactly like steps 4-7 in the above section

#### making minor changes
This for making minor changes ,such as fixing typos or small changes to existing code(no new functionality)

2. **Stage** your changes like in step 4 in above section
	` git add <files>`
3. **Amend** your most recent commit. You don't need to change your commit message
	`git commit --amend`
4. **Push and override** the remote repository. This is so that there are no insignificant commits in the history of that branch as the **most written commit is overwritten** instead

`git push --force-with-lease origin <branch_name>`
	If you need to override commits further back than most recent commit, follow the instructions for **rebasing** below


## Resolving conflicts

These shouldn't happen on your own branch for your ticket, unless someone else is also working on it and has it checkout

These usually happen on the dev and main branches when changes are made to them by others and conflict arise

### Merging

Merging is done to put the new changes from one branch into another, such as dev branch. This operation will add a new merge commit to the repository history. 

the basic steps are
1. **Checkout** the branch you want to merge the changes into, usually either dev or main
	`git checkout <branch_into>`
2. **Merge** from the branch where changes were made
	`git merge <brnach_from>` 

Steps 3-5 are optional and only need to be done if merge conflicts arise

3. Conflicts from this can arise e.g. the same part of the same file was changed in 2 different branches. Git can't automatically decide what changes to use in the new commit, so its up to the developer to make the decision

	`git status` can reveal unmerged files where the conflicts have occurred

	Git uses standard **conflict resolution** markers for us to see where 		2 different changes are coming from(the ones that caused the conflict)

	![extract showing conflict resolution window](https://i0.wp.com/css-tricks.com/wp-content/uploads/2021/10/conflict-in-textfile@2x.png?w=1130&ssl=1)

	Here, the HEAD part is changes from the branch we are merging into(e.g. main branch) and has the changes from <<<<< to ======

	The changes from incoming branch are from ====== to >>>>> sections 

	The developer has to decide which part to keep giving the context, or combine both parts into something meaningful e.g. combining both Product and Returns links in above screenshot but not keeping FAQ

	The strings of >>>>, <<<< and ==== etc have to be removed before committing

	A tool to resolve merge conflicts can be used. Use `git mergetool` to use an appropriate visual tool for this
	
	Once conflicts have been resolved, use `git add <file>` to stage the file into 
 
 4. Use `git status`again to see any other files with conflicts, and keep doing step 3 until no such files are present
 5. Finally, commit with `git commit`and optionally change the commit message to describe how the conflicts were resolved and explain changes made

For more info see explanation of merging and conflicts look into [merging and branching](https://git-scm.com/book/en/v2/Git-Branching-Basic-Branching-and-Merging#_basic_merging)


### Rebasing 
This will not add a new commit but override an existing commit. Branch history will look as though there was never a conflict. This should be used with caution as it can lead to problems in repository

It takes all the changes done on one branch and reapplies them to a different branch

basic steps are:
1. **Checkout** the branch you've made the changes in 
`git checkout <feature_branch>`
2. **Rebase** this branch on top of target branch e.g. main
`git rebase main`  
3. Fast forward **Merge** the feature branch into the target branch e.g. main
`git checkout main`
`git merge <feature_branch>`

This will result in same result as merging before, but cleaner history

rule: Do not rebase if both of these criteria apply:
1. Rebasing work **outside your computer** in GitHub repository
2. Rebasing commits **someone has already worked on**

i.e. **dont rebase commits on the remote repository that someone else has worked on**

This can create trouble than will need to be dealt with


For more information on rebasing and conflicts in it , look into [rebasing](https://git-scm.com/book/en/v2/Git-Branching-Rebasing)
- this link includes more interesting/complex rebasing and also dangers of it

## Pull requests


When you think your commit is **ready for review** to be merged into dev branch, create a pull request

1. Go to GitHub Pull Request section
2. Choose the **base** branch which is the branch we want to merge the changes into e.g. dev
3. Choose your **compare** branch e.g. your git issue branch
4. Add title and description, describe the work in title
5. Include screenshot/GIF of the main changes you have done e.g. how the game looks now or changes in the codebase. For GIFs use [screen capture tool](https://gifcap.dev/)
6. Add **at least one** reviewer so they can review the code/changes and approve the merge
7. Create the pull request
