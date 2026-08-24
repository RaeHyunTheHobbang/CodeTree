n, k = map(int, input().split())
graph = [list(map(int, input().split())) for _ in range(n)]

# Please write your code here.


from collections import deque

visited=[[0 for _ in range(n)] for _ in range(n)]
answer=[[float('inf') for _ in range(n)] for _ in range(n)]


def bfs(r:int,c:int):
    global graph,visited,answer,n,k

    Q=deque()
    visited[r][c]=1
    Q.append((r,c,1))
    

    dtmp=[0,0,-1,1]

    while Q:
        cur_r,cur_c,cur_cost=Q.popleft()
        for tr,tc in zip(dtmp,dtmp[::-1]):

            nextR,nextC=cur_r+tr,cur_c+tc
            if 0<=nextR<n and 0<=nextC<n:
                if graph[nextR][nextC]==1 and visited[nextR][nextC]==0:
                    answer[nextR][nextC]=min(answer[nextR][nextC],cur_cost)
                    Q.append((nextR,nextC,cur_cost+1))
                    visited[nextR][nextC]=1






for r in range(n):
    for c in range(n):
        if graph[r][c]==2:
            visited=[[0 for _ in range(n)] for _ in range(n)]
            answer[r][c]=0
            bfs(r,c)
        
        elif graph[r][c]==0:
            answer[r][c]=-1

for line in answer:
    for x in line:
        if x == float('inf'):
            print(-2,end=" ")
        else:
            print(x,end=" ")
    print()
        