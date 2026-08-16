import sys
from collections import deque

n=int(sys.stdin.readline().strip())
graph=[]
dtmp=[-1,1,0,0]
visited=[[0 for _ in range(n)] for _ in range(n)]


def dfs(cur_r,cur_c):
    global graph,visited,dtmp,n

    stack=deque()
    stack.append((cur_r,cur_c))
    visited[cur_r][cur_c]=1
    result=1

    while stack:
        cur_r,cur_c=stack.pop()
        for tr,tc in zip(dtmp,dtmp[::-1]):
            next_r,next_c=cur_r+tr,cur_c+tc
            if 0<=next_r<n and 0<=next_c<n:
                if visited[next_r][next_c]==0 and graph[next_r][next_c]==1:
                    visited[next_r][next_c]=1
                    result+=1
                    stack.append((next_r,next_c))

    return result
    


answer=[]
for _ in range(n):
    line=list(map(int,sys.stdin.readline().split()))
    graph.append(line)


for r in range(n):
    for c in range(n):
        if visited[r][c]==0 and graph[r][c]==1:
            answer.append(dfs(r,c))


print(len(answer))

for cur in sorted(answer):
    print(cur)
