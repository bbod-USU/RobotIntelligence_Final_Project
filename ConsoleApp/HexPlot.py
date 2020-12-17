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
    sxc = []
    syc = []
    sxm = []
    sym = []
    sxf = []
    syf = []
    
    sccx = []
    sccy = []
    hccx = []
    hccy = []

    
    
    with open("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/SquareCoveredCells.txt") as c:
        for line in c:
            x, y = line.split()
            sccx.append(int(x))
            sccy.append(int(y))
    
    with open("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/SquareDetectedMines.txt") as c:
        for line in c:
            x, y = line.split()
            sxf.append(int(x))
            syf.append(int(y))
           
                
    with open("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/HexCoveredCells.txt") as c:
        for line in c:
            x, y = line.split()
            hccx.append(int(x))
            hccy.append(int(y))
    
    with open("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/HexPath.txt") as c:
        for line in c:
            x, y = line.split()
            xc.append(int(x))
            yc.append(int(y))
            
    with open("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/SquarePath.txt") as c:
        for line in c:
            x, y = line.split()
            sxc.append(int(x))
            syc.append(int(y))
                
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
            
    fig = plt.figure(1)
    plt.plot(xc, yc)
    plt.plot(xc, yc, 'o', label='vehicle',  color='blue')
    plt.plot(xm, ym, 'o', label='all mines', color='red')
    plt.plot(xf, yf, 'o', label='detected mines', color='orange')
    plt.title('Hex Simulation')
    plt.legend(loc='lower left', fontsize='xx-small')
    matplotlib.pyplot.savefig('/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/HexTest.png')
    
    plt.plot()
    plt.close(fig)
    
    fig = plt.figure(2)
    plt.plot(sxc, syc)
    plt.plot(sxc, syc, 'o', label='vehicle',  color='blue')
    plt.plot(sxm, sym, 'o', label='all mines', color='red')
    plt.plot(sxf, syf, 'o', label='detected mines', color='orange')
    plt.title('Square Simulation')
    plt.legend(loc='lower left', fontsize='xx-small')
    matplotlib.pyplot.savefig('/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/SquareTest.png')
    plt.plot()
    plt.close(fig)
    
    fig = plt.figure(3)
    plt.plot(hccx, hccy, 'o', label='covered cells', color='red')
    plt.plot(xf, xy, 'o', label='detected mines',  color='blue')
    plt.title('Hex Coverage')
    plt.legend(loc='lower left', fontsize='xx-small')
    matplotlib.pyplot.savefig('/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/HexCoverage.png')
    plt.plot()
    plt.close(fig)
    
    fig = plt.figure(4)
    plt.plot(sccx, sccy, 'o', label='covered cells', color='red')
    plt.plot(sxf, syf, 'o', label='detected mines',  color='blue')
    plt.title('Square Coverage')
    plt.legend(loc='lower left', fontsize='xx-small')
    matplotlib.pyplot.savefig('/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/SquareCoverage.png')
    plt.plot()
    plt.close(fig)