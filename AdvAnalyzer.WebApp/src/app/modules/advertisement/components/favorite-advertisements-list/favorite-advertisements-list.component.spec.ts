import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FavoriteAdvertisementsListComponent } from './favorite-advertisements-list.component';

describe('FavoriteAdvertisementsListComponent', () => {
  let component: FavoriteAdvertisementsListComponent;
  let fixture: ComponentFixture<FavoriteAdvertisementsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FavoriteAdvertisementsListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FavoriteAdvertisementsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
