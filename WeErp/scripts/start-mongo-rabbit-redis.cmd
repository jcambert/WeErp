cd ..
docker-compose -f ./compose/mongo-rabbit-redis.yml -f ./compose/vscode.yml up -d
pause