#Найдите разность между суммой квадратов и квадратом суммы первых ста натуральных чисел.

num1 = 0
i = 1
while(i!=100):
    num1 = num1 +i*i
    i = i + 1

num2 = 0
j = 1
while(j!=100):
    num1 = num1 +j
    j = j + 1

ans = num1 - num2**2
print(ans)