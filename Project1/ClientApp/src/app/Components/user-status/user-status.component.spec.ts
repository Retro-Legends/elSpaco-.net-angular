
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { UserStatusComponent } from './user-status.component';

let component: UserStatusComponent;
let fixture: ComponentFixture<UserStatusComponent>;

describe('UserStatus component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ UserStatusComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(UserStatusComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
