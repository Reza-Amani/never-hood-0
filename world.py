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
        for x in range(world_size_x):
            self.grid_.append([])
            for y in range(world_size_y):
                self.grid_[x].append(WorldPoint(x, y, 0, None, None, None))
                self.grid_[x][y].setup_point()

    def start(self):
        new_creature = CreatureSingleCell(deep_water_x + 50, 50, Ewhat_to_eat.sunshine, 1000, 1500, 4, 0)

    def save(self):
        file = open("points_snapshot.txt", "w")
        for y in range(world_size_y):
            for point in self.grid_[y]:
               file.write(serialise(point))
               file.write('.p\n')
        file.close()
        file = open("single_cells_snapshot.txt", "w")
        for cell in self.creatures_single_cell_:
            file.write(serialise(cell))
            file.write('.c\n')
        file.close()

    def load(self):
        file = open("points_snapshot.txt", "r")
        file_lines = file.readlines()
        temp_point = WorldPoint()
        for line in file_lines:
            if line != '.c':
                de_serialise(temp_point, line)
            else:
                self.grid_[temp_point.x_][temp_point.y_] = temp_point
                temp_point = WorldPoint()

        file.close()



    def tick(self):
        self.clock_cnt_ += 1
        self.gui_.show_clock(self.clock_cnt_)
        self.gui_.show_creatures_cnt(len(self.creatures_single_cell_))
        for single_cell in self.creatures_single_cell_:
            single_cell.live()






