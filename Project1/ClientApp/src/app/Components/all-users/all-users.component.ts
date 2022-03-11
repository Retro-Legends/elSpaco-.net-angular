import {
  Component,
  ComponentFactory,
  ComponentRef,
  ComponentFactoryResolver,
  ViewContainerRef,
  ViewChild
} from '@angular/core'
import { UserStatusComponent } from '../user-status/user-status.component';
import { OfficeStatusComponent } from '../office-status/office-status.component';
import { CounterComponent } from '../../counter/counter.component';
import { FetchDataComponent } from '../../fetch-data/fetch-data.component';

@Component({
    selector: 'app-users',
    templateUrl: './all-users.component.html',
    styleUrls: ['./all-users.component.css']
})
/** Users component*/
export class AllUsersComponent {
    /** Users ctor */
    constructor() {

    }
}
