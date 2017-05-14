$(document).ready(function() {
    var CalLoading = true;
		$('#calendar').fullCalendar({
			header: {
				left: 'prev,next today',
				center: 'title',
				right: 'month,agendaWeek,agendaDay'
			},
			defaultView : 'month',
			navLinks: true, // can click day/week names to navigate views
            editable: true,
            allDaySlot: false,
            selectable: true,
            slotMinutes:15,
			eventLimit: true, // allow "more" link when too many events
			events: '/Home/GetCalendarEvents/',
		    eventDrop: function (event, dayDelta, minuteDelta, allDay, revertFunc){
		        if(confirm("Przesun¹æ?"))
		        {
		            UpdateEvent(event.id, event.start);
		        }
		        else{
		            revertFunc();
		        }
		    },
		    eventResize: function (event, dayDelta, minuteDelta, revertFunc) {
		        if(confirm("Zmieniæ czas trwania wydarzenia?"))
		        {
		            UpdateEvent(event.id, event.start, event.end);
		        }
		        else {
		            revertFunc();
		        }
		    },
		    dayClick: function (date, allDay, jsEvent, view)
		    {
		        
                $('#eventTitle').val("");
		        var moment = $('#calendar').fullCalendar('getDate');
                $('#eventDate').val(moment.format());

		        $('#eventTime').val($.fullCalendar.getDate);
		        ShowEventPopup(date);

		    },
		    viewRender: function (view, element) {

		        if (!CalLoading) {
		            if (view.name == 'month') {
		                $('#calendar').fullCalendar('removeEventSource', sourceFullView);
		                $('#calendar').fullCalendar('removeEvents');
		                $('#calendar').fullCalendar('addEventSource', sourceSummaryView);
		            }
		            else {
		                $('#calendar').fullCalendar('removeEventSource', sourceSummaryView);
		                $('#calendar').fullCalendar('removeEvents');
		                $('#calendar').fullCalendar('addEventSource', sourceFullView);
		            }
		        }
		    }
		});
		CalLoading = false;

		
});

function UpdateEvent(EventID,EventStart,EventEnd)
{
    var dataRow=
        {
            'ID': EventID,
            'NewEventStart': EventStart,
            'NewEventEnd':EventEnd
        }
    $.ajax({
        type: 'POST',
        url: "/Home/UpdateEvent",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(dataRow)
    });
}

function ShowEventPopup(date) {
    alert('Clicked on: ');
    ClearPopupFormValues();
    var modal = document.getElementById('popupEventForm');
    modal.style.display = "block";
    $('#popupEventForm').show();
    $('#eventTitle').focus();
}
function ClearPopupFormValues() {
    $('#eventID').val("");
    $('#eventTitle').val("");
    $('#eventDateTime').val("");
    $('#eventDuration').val("");
}

