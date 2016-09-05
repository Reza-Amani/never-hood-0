from gc import *
from globals import *
from point import *
from GUI import *
from world_handle import *
from creature_single_cell import *


class World(object):
    """description of class"""
    def __init__(self, gui):
        self.world_handle__ = WorldHandle(self)
        CreatureSingleCell.world_handle__ = self.world_handle__
        self.gui_ = gui
        self.grid_ = []
        self.creatures_single_cell_ = []
        self.clock_cnt_ = 0
        x_index = 0
        while x_index < world_size_x:
            self.grid_.append([WorldPoint(x_index, y) for y in range (world_size_y)])
            x_index += 1

    def start(self):
        new_creature = CreatureSingleCell(deep_water_x + 50, 50, Ewhat_to_eat.sunshine, 1000, 1500)

    def save(self):
        file = open("snapshot.txt", "w")
        file.write(serialise(self.creatures_single_cell_[0]))
        file.close()

    def tick(self):
        self.clock_cnt_ += 1
        self.gui_.show_clock(self.clock_cnt_)
        self.gui_.show_creatures_cnt(len(self.creatures_single_cell_))
        for single_cell in self.creatures_single_cell_:
            single_cell.live()






