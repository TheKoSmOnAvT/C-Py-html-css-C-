#2520 - самое маленькое число, которое делится без остатка на все числа от 1 до 10.

#Какое самое маленькое число делится нацело на все числа от 1 до 20?

def mul(x): #Функция для примера задачи
    for i in range(1,11):
        if ( x % i !=0 ):
            return False
    return True

def mul_z(x): #Функция для задачи
    for i in range(2,21):
        if ( x % i !=0 ):
            return False
    return True
#пример (2520)
num = 1
while(mul(num)!=True):
    num = num + 1
print(num)

#проверка функции
print(mul_z(1*2*3*4*5*6*7*8*9*10*11*12*13*14*15*16*17*18*19*20))

#задача
n_num = 20
while(mul_z(n_num)!=True):
    n_num = n_num*20
print(n_num)
