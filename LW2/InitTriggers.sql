DELIMITER $$

DROP TRIGGER IF EXISTS set_inspection_datetime $$
CREATE TRIGGER set_inspection_datetime
BEFORE INSERT ON Inspections
FOR EACH ROW
BEGIN
	SET NEW.date = NOW();
END
$$

DROP TRIGGER IF EXISTS set_inspection_datetime_update $$
CREATE TRIGGER set_inspection_datetime_update
BEFORE UPDATE ON Inspections
FOR EACH ROW
BEGIN
	SET NEW.date = OLD.date;
END
$$

DROP TRIGGER IF EXISTS set_last_inspecting_employee_for_failure $$
CREATE TRIGGER set_last_inspecting_employee_for_failure
BEFORE Insert ON Failures
FOR EACH ROW
BEGIN
	SET NEW.last_inspecting_employee_id = (
    select employee_id from Inspections
    where equipment_id = NEW.equipment_id
    order by Inspections.date desc
    limit 1
    );
END
$$

DELIMITER ;

-- CALL `lw2`.`lw2_init`();
