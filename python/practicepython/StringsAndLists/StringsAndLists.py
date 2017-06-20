str = "If monkeys like bananas, then I must be a monkey!"
print str.find("monkey")

x = [2,54,-2,7,12,98]
print min(x)
print max(x)

x = ["hello",2,54,-2,7,12,98,"world"]
print x[0], x[len(x)-1]

x = [19,2,54,-2,7,12,98,32,10,-3,6]
x.sort()
x1 = x[:5]
x = x[6:]
x.insert(0,x1)
print x


