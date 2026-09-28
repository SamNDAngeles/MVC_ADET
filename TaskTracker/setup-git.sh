#!/bin/bash
# Run once inside the TaskTracker folder: bash setup-git.sh
git init -b main
git add .
git commit -m "Initial commit: MVC project skeleton"

# Long-living branches (each one = one environment)
git branch release
git branch staging
git branch test
git branch dev

# Feature branches come FROM dev
git checkout dev
git checkout -b feature/task-priority
# ... do your coding here, then:
#   git add . && git commit -m "Add priority to tasks"
#   git checkout dev && git merge feature/task-priority

git checkout dev
echo "Done! See branches with: git branch"
