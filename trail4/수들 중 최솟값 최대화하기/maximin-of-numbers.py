# 최대 이분 매칭 풀이. 

n = int(input())
grid = [list(map(int, input().split())) for _ in range(n)]


# threshold 이상인 값들만 간선으로 인정했을 때
# 모든 행을 서로 다른 열에 배정할 수 있는지 검사
def can_match(threshold):
    global n 
    matched = [-1] * n
    # matched[c] = c열을 현재 사용 중인 행

    def dfs(r, visited):
        for c in range(n):

            # threshold 미만이면 사용할 수 없는 간선
            if grid[r][c] < threshold:
                continue

            if visited[c]:
                continue

            visited[c] = True

            # c열이 비어있거나,
            # 기존에 c열을 사용하던 행을 다른 열로 옮길 수 있으면
            if matched[c] == -1 or dfs(matched[c], visited):
                matched[c] = r
                return True

        return False

    count = 0

    for r in range(n):
        visited = [False] * n

        if dfs(r, visited):
            count += 1

    return count == n


# 실제 grid에 존재하는 값들만 답 후보로 사용
values = sorted(set(
    grid[r][c]
    for r in range(n)
    for c in range(n)
))

left = 0
right = len(values) - 1
answer = values[0]


# 이분 탐색 
while left <= right:
    mid = (left + right) // 2
    threshold = values[mid]

    if can_match(threshold):

        answer = threshold
        left = mid + 1
    else:
        # threshold가 너무 큼
        right = mid - 1

print(answer)



