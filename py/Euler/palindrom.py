#Число-палиндром с обеих сторон (справа налево и слева направо) читается одинаково.
#Самое большое число-палиндром, полученное умножением двух двузначных чисел – 9009 = 91 × 99.

#Найдите самый большой палиндром, полученный умножением двух трехзначных чисел.

def sn(num): #проверка на полиндром любого числа
    x=list(str(num))
    count = len(x) - 1
    count_f = 0
    while(count>=1 or count_f!=len(x)):
        if(x[count_f]!=x[count]):
            return False
        count = count - 1
        count_f = count_f + 1
    return True

n1 = 999
n2 = 999
ans_num = 0
for i in range(n1,100,-1):
    for j in range(n2,100,-1):
        if( sn(i*j) == True ):
            ans_num = i*j
            break

print(ans_num)