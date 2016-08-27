from globals import *
from global_methods import *
from graphics import Image, Point
from world_handle import *
from random import *


class CreatureSingleCell(object):
    """description of class"""
    world_handle_ = None
    dx_dy_choices = [(0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 1), (0, -1), (1, 0), (-1, 0)]
    energy_consumption_per_tick = 1

    def __init__(self, x, y, what_to_eat, breeding_thresh):
        self.x_ = x
        self.y_ = y
        self.hump_ = 0
        self.what_to_eat_ = what_to_eat
        self.breeding_thresh_ = breeding_thresh
        CreatureSingleCell.world_handle_.add_single_cell_to_grid(self, self.x_, self.y_)
        CreatureSingleCell.world_handle_.add_new_single_cell_to_list(self)
        self.image_ = Image(Point(self.x_, self.y_), 1, 1)
        self.image_.setPixel(0, 0, 'DarkGreen')
        CreatureSingleCell.world_handle_.draw_image(self.image_)

        if self.what_to_eat_ == Ewhat_to_eat.sunshine:
            self.action_single_cell_eating = self.single_cell_eating_from_sun
        elif self.what_to_eat_ == Ewhat_to_eat.organics:
            self.action_single_cell_eating = self.single_cell_eating_organics
        elif self.what_to_eat_ == Ewhat_to_eat.single_cell:
            self.action_single_cell_eating = self.single_cell_eating_single_cell

    def live(self):
        (dx, dy) = self.action_single_cell_move_decision()

        self.action_single_cell_eating(dx, dy)
        self.action_single_cell_energy_burning()
        self.action_single_cell_breeding(dx, dy)
        self.action_single_cell_moving(dx, dy)

    def action_single_cell_energy_burning(self):
        self.hump_ -= CreatureSingleCell.energy_consumption_per_tick * 2
        CreatureSingleCell.world_handle_.add_organics(self.x_, self.y_, CreatureSingleCell.energy_consumption_per_tick)

    def action_single_cell_breeding(self, dx, dy):
        if self.hump_ > self.breeding_thresh_:
            if random() > 0.95:
                if CreatureSingleCell.world_handle_.check_vacancy_single_cell(self.x_ + dx, self.y_ + dy):
                    self.hump_ -= self.breeding_thresh_/2
                    child = CreatureSingleCell(self.x_ + dx, self.y_ + dy, self.what_to_eat_, self.breeding_thresh_)
                    child.hump_ = self.breeding_thresh_/2

    def action_single_cell_move_decision(self):
        (dx, dy) = choice(CreatureSingleCell.dx_dy_choices)
        if not check_boundaries(self.x_+dx, self.y_+dy):
            (dx, dy) = (0, 0)
        return dx, dy

    def action_single_cell_moving(self, dx, dy):
        if CreatureSingleCell.world_handle_.check_vacancy_single_cell(self.x_ + dx, self.y_ + dy):
            self.image_.move(dx, dy)
            CreatureSingleCell.world_handle_.add_single_cell_to_grid(self, self.x_+dx, self.y_+dy)
            CreatureSingleCell.world_handle_.remove_single_cell_from_grid(self.x_, self.y_)
            self.x_ += dx
            self.y_ += dy

    def action_single_cell_eating(self, dx , dy):
        pass

    def single_cell_eating_from_sun(self, dx, dy):
        self.hump_ += CreatureSingleCell.world_handle_.get_xy_sunshine(self.x_, self.y_)

    def single_cell_eating_organics(self, dx, dy):
        pass

    def single_cell_eating_single_cell(self, dx, dy):
        pass