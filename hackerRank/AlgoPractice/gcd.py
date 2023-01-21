def greatest_common_divisor(x, y):
    while y > 0:
        temp = y
        y = x % y
        x = temp
    return x


val = greatest_common_divisor(252, 105)
print("Greatest common divisor: {0}".format(val))
