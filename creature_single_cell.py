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
    mutation_list = ['self.age_max_*=1.1', 'self.age_max_*=0.9', 'self.what_to_eat_+= 1', 'self.breeding_thresh_*=1.1',
                     'self.breeding_thresh_*=0.9']

    def __init__(self, x, y, what_to_eat, breeding_thresh):
        self.x_ = x
        self.y_ = y
        self.hump_ = 0
        self.age_ = 0
        self.age_max_ = 2500
        self.what_to_eat_ = what_to_eat
        self.breeding_thresh_ = breeding_thresh
        CreatureSingleCell.world_handle_.add_single_cell_to_grid(self, self.x_, self.y_)
        CreatureSingleCell.world_handle_.add_new_single_cell_to_list(self)
        self.image_ = Image(Point(self.x_, self.y_), 1, 1)
        CreatureSingleCell.world_handle_.draw_image(self.image_)
        self.update_single_cell()

    def update_single_cell(self):
        if self.what_to_eat_ == Ewhat_to_eat.sunshine:
            self.action_single_cell_eating = self.single_cell_eating_from_sun
            self.image_.setPixel(0, 0, 'Green')
        elif self.what_to_eat_ == Ewhat_to_eat.organics:
            self.action_single_cell_eating = self.single_cell_eating_organics
            self.image_.setPixel(0, 0, 'Yellow')
        elif self.what_to_eat_ == Ewhat_to_eat.single_cell:
            self.action_single_cell_eating = self.single_cell_eating_single_cell
            self.image_.setPixel(0, 0, 'Red')
        else:
            self.action_single_cell_eating = self.action_null
            self.image_.setPixel(0, 0, 'Gray')

    def live(self):
        (dx, dy) = self.action_single_cell_move_decision()

        self.action_single_cell_eating(dx, dy)
        self.action_single_cell_energy_burning()
        if not self.action_single_cell_dying():
            self.action_single_cell_breeding(dx, dy)
            self.action_single_cell_moving(dx, dy)
            if random() < 0.001:
                self.action_single_cell_mutation()

    def action_single_cell_mutation(self):
        exec(choice(CreatureSingleCell.mutation_list))
        self.update_single_cell()

    def action_single_cell_dying(self):
        self.age_ += 1
        if self.age_ > self.age_max_ or self.hump_ < 1:
            CreatureSingleCell.world_handle_.add_organics(self.x_, self.y_, self.hump_)
            CreatureSingleCell.world_handle_.undraw_image(self.x_, self.y_)
            CreatureSingleCell.world_handle_.remove_single_cell_from_list(self.x_, self.y_)
            CreatureSingleCell.world_handle_.remove_single_cell_from_grid(self.x_, self.y_)
            return True
        else:
            return False

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
            if CreatureSingleCell.world_handle_.get_xy_water(self.x_ + dx, self.y_ + dy) != Ewater.dry_land:
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
        food = CreatureSingleCell.world_handle_.get_organics(self.x_, self.y_)
        self.hump_ += food
        CreatureSingleCell.world_handle_.add_organics(self.x_, self.y_, -food)

    def single_cell_eating_single_cell(self, dx, dy):
        if (dx, dy) != (0, 0):
            if not CreatureSingleCell.world_handle_.check_vacancy_single_cell(self.x_+dx, self.y_+dy):
                self.hump_ += CreatureSingleCell.world_handle_.get_grid_single_cell_hump(self.x_+dx, self.y_+dy)
                CreatureSingleCell.world_handle_.undraw_image(self.x_+dx, self.y_+dy)
                CreatureSingleCell.world_handle_.remove_single_cell_from_list(self.x_+dx, self.y_+dy)
                CreatureSingleCell.world_handle_.remove_single_cell_from_grid(self.x_+dx, self.y_+dy)

    def action_null(self, x, y):
        pass