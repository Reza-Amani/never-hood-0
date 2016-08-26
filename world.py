from gc import *
from globals import *
from point import *
from GUI import *
from world_handle import *
from creature_single_cell import *


class World(object):
    """description of class"""
    def __init__(self, gui):
        self.world_handle_ = WorldHandle(self)
        self.gui_ = gui
        self.grid_ = []
        self.creatures_single_cell_ = []
        self.clock_cnt_ = 0
        x_index = 0
        while x_index < world_size_x:
            self.grid_.append([point(x_index, y) for y in range (world_size_y)])
            x_index += 1

    def start(self):
        new_creature = CreatureSingleCell(coastal_water_x + 50, 100, self.world_handle_)
        self.creatures_single_cell_.append(new_creature)

    def tick(self):
        self.clock_cnt_ += 1
        self.gui_.show_clock(self.clock_cnt_)
        self.gui_.show_creatures_cnt(len(self.creatures_single_cell_))
        for single_cell in self.creatures_single_cell_:
            single_cell.live()






