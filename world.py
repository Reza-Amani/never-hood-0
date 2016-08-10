from point import *
from GUI import *
from creature import *
class World(object):
    """description of class"""
    def __init__(self, gui):
        self.gui = gui
        self.grid = []
        self.Creatures = []
        self.clock_cnt = 0
        x_index = 0
        while x_index < 400:
            self.grid.append([point(x_index, y) for y in range (400)])
            x_index = x_index+1

    def start(self):
        cr = Creature(100,100)
        cr.p.draw(self.gui.field)
        self.Creatures.append(cr)

    def tick(self):
        self.clock_cnt = self.clock_cnt +1
        self.gui.show_clock(self.clock_cnt)
        for cr in self.Creatures:
            cr.live()




