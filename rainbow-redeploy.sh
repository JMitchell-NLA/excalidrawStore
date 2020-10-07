cd ./excalidraw
npm run build;
cd ..
source ./copybuild.sh;
echo "what commit message do you want?"
read msg
git add -A;
git commit -a -m "$msg";
git push;
ssh root@kooks-does.net "cd /cherry/excalidrawStore && git pull"
echo "all done!"


