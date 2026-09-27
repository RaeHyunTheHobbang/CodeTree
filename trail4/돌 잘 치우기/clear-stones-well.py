import sys
from collections import deque

answer=0
n,k,m=map(int,sys.stdin.readline().split())
start,info=[],[]
graph=[]
for _ in range(n):
    line=list(map(int,sys.stdin.readline().split()))
    graph.append(line)



for _ in range(k):
    r,c=map(int,sys.stdin.readline().split())
    start.append((r-1,c-1))

for r in range(n):
    for c in range(n):
        if graph[r][c]==1:
            info.append((r,c))

def bfs(start:list,graph:list)->int:
    global n,k,m

    result=0

    Q=deque()
    visited=[[0 for _ in range(n)] for _ in range(n)]
    for r,c in start:
        Q.append((r,c))
        visited[r][c]=1
        result+=1

    dtmp=[0,0,-1,1]

    while Q:
        cur_r,cur_c=Q.popleft()
        for dr,dc in zip(dtmp,dtmp[::-1]):
            tr,tc=cur_r+dr,cur_c+dc
            if 0<=tr<n and 0<=tc<n:
                if graph[tr][tc]==0:
                    if visited[tr][tc]==0:
                        visited[tr][tc]=1
                        result+=1
                        Q.append((tr,tc))
    
    return result

def back_track(cur_idx=0,cur_depth=0):
    global info,graph,m,start,answer

    if cur_depth==m:
        answer=max(answer,bfs(start,graph))

        return
    
    for i in range(cur_idx, len(info)):
        r,c=info[i]
        graph[r][c]=0
        back_track(i+1,cur_depth+1)
        graph[r][c]=1




back_track()

print(answer)
                    
