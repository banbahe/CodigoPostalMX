const ctrlCourse = require('../controllers/course.controller')
module.exports = function(app) {
   
    app.post('/api/courses',ctrlCourse.Create);
    app.get('/api/courses',ctrlCourse.GetAll);
    app.get('/api/courses/:courseid',ctrlCourse.Get);
    app.delete('/api/courses/:courseid',ctrlCourse.Delete);
    app.patch('/api/courses/:courseid',ctrlCourse.Update);
};
