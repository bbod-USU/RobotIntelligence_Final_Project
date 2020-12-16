import numpy as np
import matplotlib.pyplot as plt
import matplotlib


if __name__ == "__main__":
    xc = []
    yc = []
    xm = []
    ym = []
    xf = []
    yf = []
    with open("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/HexPath.txt") as c:
        for line in c:
            x, y = line.split()
            xc.append(int(x))
            yc.append(int(y))

    with open("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/Mines.txt") as m:
        for line in m:
            x, y = line.split()
            xm.append(int(x))
            ym.append(int(y))

    with open("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/HexDetectedMines.txt") as f:
        for line in f:
            x, y = line.split()
            xf.append(int(x))
            yf.append(int(y))
    fig = plt.figure()
    plt.plot(xc, yc)
    plt.plot(xc, yc, 'o', label='vehicle',  color='blue')
    plt.plot(xm, ym, 'o', label='all mines', color='red')
    plt.plot(xf, yf, 'o', label='detected mines', color='orange')
    plt.title('Hex Simulation')
    plt.legend(loc='lower left', fontsize='xx-small')

    matplotlib.pyplot.savefig('/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/HexTest.png')
    plt.close(fig)