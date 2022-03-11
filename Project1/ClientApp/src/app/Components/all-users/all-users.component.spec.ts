import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { AllUsersComponent } from './all-users.component';

let component: AllUsersComponent;
let fixture: ComponentFixture<AllUsersComponent>;

describe('Users component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ UsersComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(UsersComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
