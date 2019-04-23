def func(x):
    if x>10:
        return
    print(x)
    return func(x+1)


print(func(0))