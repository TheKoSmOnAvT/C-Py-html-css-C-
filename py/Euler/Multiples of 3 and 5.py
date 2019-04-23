n = int(input())
num=0
for i in range(0,n):
    if(i%5 == 0 or i%3 == 0):
        num = num + i

print(num)