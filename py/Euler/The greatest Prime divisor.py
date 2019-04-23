#Простые делители числа 13195 - это 5, 7, 13 и 29.
#Каков самый большой делитель числа 600851475143, являющийся простым числом?

def check(x):
    if(x % 2 == 0 or x % 3 == 0 or x % 7 ==0):
        return True
    else:
        return False
def PD(x):
    ch=True
    n=x
    while(True):
        if( check(n)==False ):
            return n
        else:
            n = n - 1




n=600851475143
print(PD(n))