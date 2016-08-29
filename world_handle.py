from globals import *
from graphics import *
from world import *


class WorldHandle(object):
    def __init__(self, world):
        self.world_ = world

    def add_organics(self, x, y, d_organics):
        self.world_.grid_[x][y].organic_ += d_organics

    def get_organics(self, x, y):
        return self.world_.grid_[x][y].organic_

    def add_single_cell_to_grid(self, single_cell, x, y):
        self.world_.grid_[x][y].single_cell_ = single_cell

    def remove_single_cell_from_grid(self, x, y):
        self.world_.grid_[x][y].single_cell_ = None

    def remove_single_cell_from_list(self, x, y):
        self.world_.creatures_single_cell_.remove(self.world_.grid_[x][y].single_cell_)

    def draw_image(self, image):
        image.draw(self.world_.gui_.field)

    def undraw_image(self, x, y):
        self.world_.grid_[x][y].single_cell_.image_.undraw()

    def check_vacancy_single_cell(self, x, y):
        if self.world_.grid_[x][y].single_cell_ is None:
            return True
        else:
            return False

    def get_grid_single_cell_hump(self, x, y):
        return self.world_.grid_[x][y].single_cell_.hump_

    def get_xy_sunshine(self, x, y):
        return self.world_.grid_[x][y].sunshine

    def add_new_single_cell_to_list(self, single_cell):
        self.world_.creatures_single_cell_.append(single_cell)